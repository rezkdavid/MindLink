import unittest
from unittest.mock import patch
import tensorflow as tf
from model.MI.Network.BiLSTM_with_Attention_tf2 import BiLSTMWithAttention

class BiLSTMWithAttentionTest(unittest.TestCase):

    def setUp(self):
        # Mock data setup
        self.n_samples = 10  # Small number for testing
        self.n_features = 64
        self.n_time_steps = 64
        self.n_classes = 4  # Matches the model configuration

        self.train_data = tf.random.uniform([self.n_samples, self.n_time_steps, self.n_features])
        self.train_labels = tf.keras.utils.to_categorical(tf.random.uniform([self.n_samples], maxval=self.n_classes, dtype=tf.int32), num_classes=self.n_classes)
        self.test_data = tf.random.uniform([self.n_samples, self.n_time_steps, self.n_features])
        self.test_labels = tf.keras.utils.to_categorical(tf.random.uniform([self.n_samples], maxval=self.n_classes, dtype=tf.int32), num_classes=self.n_classes)

        self.batch_size = 2  # Small batch size for testing

    @patch('DatasetAPI.DataLoader_tf2.load_dataset')
    def test_model_training(self, mock_load_dataset):
        # Mock the load_dataset function to return our small, random dataset
        mock_load_dataset.return_value = ((self.train_data, self.train_labels), (self.test_data, self.test_labels))

        # Model configuration
        lstm_size = 256
        attention_size = 8
        n_hidden = 64
        n_classes = 4
        learning_rate = 1e-4

        # Initialize the model
        model = BiLSTMWithAttention(lstm_size=lstm_size, attention_size=attention_size, n_hidden=n_hidden, n_classes=n_classes)

        # Compile the model
        model.compile(optimizer=tf.keras.optimizers.Adam(learning_rate=learning_rate),
                      loss='categorical_crossentropy',
                      metrics=['accuracy'])

        # Prepare a very small dataset
        train_dataset = tf.data.Dataset.from_tensor_slices((self.train_data, self.train_labels)).batch(self.batch_size)
        test_dataset = tf.data.Dataset.from_tensor_slices((self.test_data, self.test_labels)).batch(self.batch_size)

        # Train the model for a single epoch to ensure it works without throwing exceptions
        history = model.fit(train_dataset, epochs=1, validation_data=test_dataset)

        # Check that the model actually trained for 1 epoch
        self.assertEqual(len(history.history['loss']), 1)

if __name__ == '__main__':
    unittest.main()
