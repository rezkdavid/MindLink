import asyncio
import websockets
import tensorflow as tf
import numpy as np
import pandas as pd

# Load model
model = tf.keras.models.load_model('trained_model/BiLSTMWithAttention')

async def predict(websocket, path):
    async for message in websocket:

        data = np.array(pd.read_json(message))
        data_reshaped = data.reshape((-1, 64, 64))

        # Predict
        predictions = model.predict(data_reshaped)
        predicted_class = np.argmax(predictions, axis=1)[0]
        print("predicted label: " + str(predicted_class))

        await websocket.send(str(predicted_class))

# Set up WebSocket server
port = 8765
start_server = websockets.serve(predict, "localhost", port)
print("start listening on port " + str(port))
asyncio.get_event_loop().run_until_complete(start_server)
asyncio.get_event_loop().run_forever()
