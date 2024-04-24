import numpy as np
import pandas as pd
import tensorflow as tf

# 步骤1: 加载测试数据
# 假设你的CSV文件中包含了特征和标签，且标签在最后一列
df_test = pd.read_csv('deployment/test_data/label_3.csv')
test_data = df_test.iloc[:, :-1].values  # 提取特征
test_labels = df_test.iloc[:, -1].values  # 提取标签

# 将数据reshape成模型期望的格式
n_timesteps = 64  # 根据模型配置调整
n_features = 64  # 根据模型配置调整
test_data_reshaped = test_data.reshape((-1, n_timesteps, n_features))

# 步骤2: 加载模型
model = tf.keras.models.load_model('trained_model/BiLSTMWithAttention')

# 步骤3: 执行预测
predictions = model.predict(test_data_reshaped)
predicted_classes = np.argmax(predictions, axis=1)

# 如果你的test_labels是one-hot编码的，你需要转换它们以进行比较
# 如果test_labels已经是类别编码，可以跳过这一步
test_labels_classes = np.argmax(test_labels, axis=1) if test_labels.ndim > 1 else test_labels

# 步骤4: 比较预测结果和测试标签
accuracy = np.mean(predicted_classes == test_labels_classes)
print("预测准确率:", accuracy)

# 打印出预测结果和实际标签进行比较
for i in range(len(predicted_classes)):
    print(f"样本 {i}: 预测类别 = {predicted_classes[i]}, 实际类别 = {test_labels_classes[i]}")
