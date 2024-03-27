"""
@Author: Hanbin Qin
@Date: Mar 24, 2021

Prerequisite: Python 3.6 Tensorflow 2.6.0

Attention mechanism layer which reduces RNN/Bi-RNN outputs with Attention vector.
The idea was proposed in the article by Z. Yang et al., "Hierarchical Attention Networks
for Document Classification", 2016: http://www.aclweb.org/anthology/N16-1174.

Based on https://github.com/SuperBruceJia/EEG-DL/blob/master/Models/main-BiLSTM-with-Attention.py
Modified to use Tensorflow 2.X

"""
import os
import tensorflow as tf
from DatasetAPI.DataLoader_tf2 import load_dataset
from model.MI.Network.BiLSTM_with_Attention_tf2 import BiLSTMWithAttention
from tensorflow.keras.callbacks import TensorBoard
import datetime

# The directory of dataset
dir_path = '../../data/MI/EEG-Motor-Movement-Imagery-Dataset/RNN/csv'
# Load the dataset
(train_data, train_labels), (test_data, test_labels) = load_dataset(dir_path)

# Model configuration
n_input = 64
max_time = 64
lstm_size = 256  # Number of units in LSTM layers
attention_size = 8  # Size of the attention layer
n_hidden = 64  # Number of units in the fully connected layer
n_classes = 4  # Number of output classes
batch_size = 1024
num_epochs = 200
learning_rate = 1e-4

# Initialize the model
model = BiLSTMWithAttention(lstm_size=lstm_size, attention_size=attention_size, n_hidden=n_hidden, n_classes=n_classes)

# Compile the model
model.compile(optimizer=tf.keras.optimizers.Adam(learning_rate=learning_rate),
              loss='categorical_crossentropy',
              metrics=['accuracy'])

# Preparing the data
# train_dataset = tf.data.Dataset.from_tensor_slices((train_data, train_labels)).batch(batch_size)
# test_dataset = tf.data.Dataset.from_tensor_slices((test_data, test_labels)).batch(batch_size)

n_timesteps = 64  # This matches `max_time`
n_features = 64  # This matches `n_input`

# Reshape the data
train_data_reshaped = train_data.reshape((-1, n_timesteps, n_features))
test_data_reshaped = test_data.reshape((-1, n_timesteps, n_features))

# Update dataset creation to use reshaped data
train_dataset = tf.data.Dataset.from_tensor_slices((train_data_reshaped, train_labels)).batch(batch_size)
test_dataset = tf.data.Dataset.from_tensor_slices((test_data_reshaped, test_labels)).batch(batch_size)

# Set log file path
log_dir = "Saved_Files/BiLSTMWithAttention/logs/fit/" + datetime.datetime.now().strftime("%Y%m%d-%H%M%S")
tensorboard_callback = TensorBoard(log_dir=log_dir, histogram_freq=1)

# Train the model
model.fit(train_dataset, epochs=num_epochs, validation_data=test_dataset, callbacks=[tensorboard_callback])


# Save the model
model.save('Saved_Files/BiLSTMWithAttention')
