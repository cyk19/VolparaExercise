import axios from 'axios';

const apiHost = 'http://localhost:5191/api';

const faceDetectionApiService = {
  post: async (imageStrings) => {
    try {
      const response = await axios.post(`${apiHost}/FaceDetection`, imageStrings);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },
};

export default faceDetectionApiService;