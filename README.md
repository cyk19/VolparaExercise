# VolparaExercise

Missed requirements:
1. Only display images with at least 70 % face detection confidence level (currently displays all)
2. Provide images through the frontend (currently provide images from the backend)

Things to improve on:
1. Set up a db layer to read and store images, log events
1. Error handling - loggers to log unexpected events to database (non-image files, cloud api down, server inactive issues etc.)
2. Code and architecture documentation - increase code readability when other dev comes on board
3. Unit test on controllers - all cases incl. edge cases
4. Session handling if image uploaded is sensitive
5. Integration testing / Jest test on UI
