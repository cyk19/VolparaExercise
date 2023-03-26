import React, { useState, useEffect } from 'react';
import axios from 'axios';
import imagesApiService from '../Services/imagesApiService';
import faceDetectionApiService from '../Services/faceDetectionApiService';

function ImageList() {
  const [images, setImages] = useState([]);
  const [confidenceLevels, setConfidenceLevels] = useState([]);

  useEffect(() => {
    async function fetchImages() {
      const response = await imagesApiService.get();
      setImages(response);

      if (images.length > 0) {
        getFaceDetectConfidence(images);
      }
    }

    async function getFaceDetectConfidence(images) {
      const response = await faceDetectionApiService.post(images);
      setConfidenceLevels(response);
    }

    fetchImages()
  }, [confidenceLevels]);

  
  return (
    <div>
      {images.map((image, index) => (<div>
        <img key={index} src={`data:image/jpeg;base64,${image}`} />
        <p>{confidenceLevels[index]}</p>
        </div>
      ))}
    </div>
  );
}

export default ImageList;
