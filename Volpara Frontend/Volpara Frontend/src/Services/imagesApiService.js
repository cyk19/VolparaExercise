import axios from 'axios';

const apiHost = 'http://localhost:5191/api';

const imagesApiService = {
  get: async () => {
    try {
      const response = await axios.get(`${apiHost}/Images`);
      return response.data;
    } catch (error) {
      console.error(error);
    }
  },
};

export default imagesApiService;