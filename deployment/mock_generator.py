# using python 3.6

import pandas as pd
import keyboard
import websockets
import asyncio
import json

# load dataset
datasets = {
    'up': pd.read_csv('test_data/label_0.csv'),
    'down': pd.read_csv('test_data/label_1.csv'),
    'left': pd.read_csv('test_data/label_2.csv'),
    'right': pd.read_csv('test_data/label_3.csv')
}

# send data via web socket
async def send_message(data):
    address = "ws://localhost:8765"  # server address
    # print("Sending JSON data:", data)
    async with websockets.connect(address) as websocket:
        await websocket.send(data)

# create event loop
loop = asyncio.get_event_loop()


def handle_event(event):
    if event.name in ['up', 'down', 'left', 'right']:
        # random sample data
        sample = datasets[event.name].sample(1).iloc[:, :-1]
        # convert row to 2D array
        sample_array = sample.values.reshape(64, 64)
        # convert array to JSON
        json_data = json.dumps(sample_array.tolist())
        print(f"Sending data for {event.name}")
        loop.run_until_complete(send_message(json_data))


print("Start listening to keyboard input...")
keyboard.on_press(handle_event)


try:
    keyboard.wait()
except KeyboardInterrupt:
    loop.close()

