import unittest
import asyncio
import websockets
import numpy as np
import pandas as pd


class WebSocketServerTest(unittest.TestCase):
    def setUp(self):
        # set up async loop test
        self.loop = asyncio.new_event_loop()
        asyncio.set_event_loop(self.loop)

    async def async_test_predict(self):
        # connect to websocket server
        uri = "ws://localhost:8765"
        async with websockets.connect(uri) as websocket:
            # mock EEG data
            data = np.random.rand(64, 64)  # random data for test
            data_df = pd.DataFrame(data)
            message = data_df.to_json()  # convert dataframe to JSON

            # send request
            await websocket.send(message)
            response = await websocket.recv()

            # check if the received message is a prediction
            self.assertTrue(response.isdigit(), "The response should be a digit representing the predicted class.")

    def test_predict(self):
        # run async test
        self.loop.run_until_complete(self.async_test_predict())
