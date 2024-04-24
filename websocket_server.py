# using Python 3.6
# Author: Hanbin Qin
# This server will listen to port 8765 for EEG data, and call trained model to predict its label,
# and send corresponding control command to Unity via port 8766.

import asyncio
import websockets
import tensorflow as tf
import numpy as np
import json

# Load the model
model = tf.keras.models.load_model('trained_model/BiLSTMWithAttention')

# Global WebSocket connection for Unity
unity_websocket = None

async def handle_data_connection(websocket, path):
    global unity_websocket
    try:
        async for message in websocket:
            data = np.array(json.loads(message))
            data_reshaped = data.reshape((-1, 64, 64))
            predictions = model.predict(data_reshaped)
            predicted_class = np.argmax(predictions, axis=1)[0]
            print("predicted class: ", predicted_class)
            # convert predicted label into control command
            direction = ["up", "down", "left", "right"][predicted_class]
            press_message = f"{direction}_press"
            release_message = f"{direction}_release"

            # send control command to Unity
            if unity_websocket:
                await send_control_command(press_message, release_message)
            else:
                print("Unity connection is not established.")
    except Exception as e:
        print(f"Error in handle_data_connection: {e}")


async def send_control_command(press_message, release_message):
    global unity_websocket
    try:
        await unity_websocket.send(press_message)
        print(f"Sent: {press_message}")

        await asyncio.sleep(0.6) # interval time between key press and key release

        await unity_websocket.send(release_message)
        print(f"Sent: {release_message}")
    except Exception as e:
        print(f"Error in send_control_command: {e}")

async def handle_unity_connection(websocket, path):
    global unity_websocket
    unity_websocket = websocket
    try:
        async for message in websocket:
            print(f"Unity says: {message}")
    except Exception as e:
        print(f"Error in handle_unity_connection: {e}")
        unity_websocket = None  # Reset on error or disconnect

async def start_servers():
    server_data = websockets.serve(handle_data_connection, "localhost", 8765)
    server_unity = websockets.serve(handle_unity_connection, "localhost", 8766)
    await asyncio.gather(server_data, server_unity)

def main():
    asyncio.get_event_loop().run_until_complete(start_servers())
    asyncio.get_event_loop().run_forever()

if __name__ == "__main__":
    print("Servers starting...")
    main()
