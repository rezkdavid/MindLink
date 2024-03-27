"""
@Author: Hanbin Qin
@Date: Mar 24, 2024

Based on https://github.com/SuperBruceJia/EEG-DL/blob/master/Models/Network/BiLSTM_with_Attention.py
Modified to use Tensorflow 2.X

"""

import tensorflow as tf

class Attention(tf.keras.layers.Layer):
    def __init__(self, attention_size, **kwargs):
        super(Attention, self).__init__(**kwargs)
        self.attention_size = attention_size

    def build(self, input_shape):
        self.W = self.add_weight(name='att_weight', shape=(input_shape[-1], self.attention_size),
                                 initializer='glorot_uniform', trainable=True)
        self.b = self.add_weight(name='att_bias', shape=(self.attention_size,),
                                 initializer='zeros', trainable=True)
        self.u = self.add_weight(name='att_u', shape=(self.attention_size,),
                                 initializer='glorot_uniform', trainable=True)
        super(Attention, self).build(input_shape)

    def call(self, inputs):
        v = tf.tanh(tf.tensordot(inputs, self.W, axes=1) + self.b)
        vu = tf.tensordot(v, self.u, axes=1)
        alphas = tf.nn.softmax(vu, axis=1)
        output = tf.reduce_sum(inputs * tf.expand_dims(alphas, -1), axis=1)
        return output, alphas

class BiLSTMWithAttention(tf.keras.Model):
    def __init__(self, lstm_size, attention_size, n_hidden, n_classes, **kwargs):
        super(BiLSTMWithAttention, self).__init__(**kwargs)
        self.bilstm = tf.keras.layers.Bidirectional(tf.keras.layers.LSTM(lstm_size, return_sequences=True))
        self.attention = Attention(attention_size)
        self.fc1 = tf.keras.layers.Dense(n_hidden, activation='relu')
        self.dropout = tf.keras.layers.Dropout(0.25)
        self.fc2 = tf.keras.layers.Dense(n_classes, activation='softmax')

    def call(self, inputs, training=False):
        x = self.bilstm(inputs)
        x, _ = self.attention(x)
        x = self.fc1(x)
        if training:
            x = self.dropout(x, training=training)
        x = self.fc2(x)
        return x
