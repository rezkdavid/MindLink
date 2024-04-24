import pandas as pd

# 读取数据集
data = pd.read_csv('../data/MI/EEG-Motor-Movement-Imagery-Dataset/RNN/csv/test_set.csv', header=None)

# 读取标签
labels = pd.read_csv('../data/MI/EEG-Motor-Movement-Imagery-Dataset/RNN/csv/test_label.csv', header=None)

# 将数据和标签合并
combined = pd.concat([data, labels], axis=1)

# 保存合并后的数据到新文件
combined.to_csv('data_label_combined.csv', index=False, header=False)

# 提取标签为0的数据
label_zero_data = combined[combined.iloc[:, -1] == 3]
label_zero_data.to_csv('test_data/label_3.csv', index=False, header=False)

