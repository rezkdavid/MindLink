"""
@Author: Hanbin Qin
@Date: Mar 24, 2021

"""
import pandas as pd
import tensorflow as tf


def load_dataset(dir_path):
    train_data = pd.read_csv(f'{dir_path}/training_set.csv', header=None).values
    train_labels = pd.read_csv(f'{dir_path}/training_label.csv', header=None).values
    test_data = pd.read_csv(f'{dir_path}/test_set.csv', header=None).values
    test_labels = pd.read_csv(f'{dir_path}/test_label.csv', header=None).values

    # One-hot encode labels if needed
    train_labels = tf.keras.utils.to_categorical(train_labels, num_classes=4)
    test_labels = tf.keras.utils.to_categorical(test_labels, num_classes=4)

    return (train_data, train_labels), (test_data, test_labels)
