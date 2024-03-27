import numpy as np
import torch
import torch.nn as nn
import torch.optim as optim
from torch.utils.data import DataLoader, TensorDataset

data_path = '/data'

train_data = np.load(data_path + '\\train_data.npy')
test_data = np.load(data_path + '\\test_data.npy')
train_label = np.load(data_path + '\\train_label.npy')
test_label = np.load(data_path + '\\test_label.npy')

#To convert the data into PyTorch tensors
x_train_tensor = torch.Tensor(train_data)
y_train_tensor = torch.LongTensor(train_label)
x_test_tensor = torch.Tensor(test_data)
y_test_tensor = torch.LongTensor(test_label)

# device = torch.device("cuda") #Setting GPU on your computer
device = torch.device("cuda" if torch.cuda.is_available() else "cpu") #Setting GPU on your computer

train_dataset = TensorDataset(x_train_tensor.to(device), y_train_tensor.to(device)) # input data to Tensor dataloader
train_loader = DataLoader(train_dataset, batch_size=64, drop_last=True, shuffle=True) #  Batch size refers to the number of data sample
test_dataset = TensorDataset(x_test_tensor.to(device), y_test_tensor.to(device))
test_loader = DataLoader(test_dataset, batch_size=64,  drop_last=True,shuffle=False)

class EEGAutoencoderClassifier(nn.Module):
    def __init__(self, num_classes):
        super(EEGAutoencoderClassifier, self).__init__()
        self.encoder = nn.Sequential(
            nn.Linear(64 * 795, 256), # Input dimention is 64 channel * 795 time point, and use 256 units for first NN layer
            nn.ReLU(), # Use ReLu function for NN training
            nn.Linear(256, 128), # 256 NN units to 128 units
            nn.ReLU(),
            nn.Linear(128, 64),#  128 NN units to 64 units
            nn.ReLU()
        )
        self.classifier = nn.Sequential(
            nn.Linear(64, num_classes), # num_classes is 5 (hello,” “help me,” “stop,” “thank you,” and “yes”)
            nn.LogSoftmax(dim=1)  # Use LogSoftmax for multi-class classification
        )

    def forward(self, x):
        x = x.view(x.size(0), -1)
        x = self.encoder(x)

        # import pdb;pdb.set_trace()
        x = self.classifier(x)
        return x

num_classes = 5  # setting final output class
model = EEGAutoencoderClassifier(num_classes).to(device)
criterion = nn.NLLLoss()  # Use NLLLoss function to optimize
optimizer = optim.Adam(model.parameters(), lr=0.001)  # Setting parameters learning rate = 0.001

num_epochs = 20 # setting training epochs (Number of training iterations)
for epoch in range(num_epochs):
    model.train()
    for data, labels in train_loader:
        optimizer.zero_grad()
        outputs = model(data)
        loss = criterion(outputs, labels)
        loss.backward()
        optimizer.step()

    print(f'Epoch {epoch + 1}/{num_epochs}, Loss: {loss.item()}')

model.eval() # Evaluate your model
correct = 0
total = 0

with torch.no_grad():
    for data, labels in test_loader:
        outputs = model(data)
        _, predicted = torch.max(outputs.data, 1)
        total += labels.size(0)
        correct += (predicted == labels).sum().item()

accuracy = correct / total
print(f'Test Accuracy: {accuracy * 100:.2f}%')