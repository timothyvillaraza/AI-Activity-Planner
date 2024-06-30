### Demo
<iframe width="560" height="315" src="https://www.youtube.com/embed/Ui9V7CoP6mk" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>

## AI Adventure Assistant

### Inspiration
We were inspired to experiment with OpenAI's ChatGPT language model due to its powerful capabilities. Our team created The AI Adventure Assistant, a program that generates an itinerary of things to do around the user's location, taking into account their interests and special requests.

### What It Does
The AI Adventure Assistant generates an itinerary based on the user's location and weather data, using the Open-Meto API to collect weather data based on location. OpenAI's GPT-3.5-turbo is used to generate the itinerary based on the user's interests and special requests.

### How We Built It
The project uses the ASP.NET Core Web Framework. It uses the Open-Meto API to retrieve weather data from the location of the user and the GPT-3 language model to generate the itinerary for the user. It was built with web mobile users in mind but works with any screen resolution thanks to the responsive design elements of TailWind CSS.

We engineered our prompts in order to get the itinerary item format that we desired.

### Challenges We Ran Into
We faced several challenges during the development of The AI Adventure Assistant, including getting our team of undergrads up to speed with an unfamiliar framework and the use of the MVC design pattern. A significant amount of time was spent figuring out the framework instead of coding right away. We built a back-end service layer that houses three different API integrations, and we had difficulty passing data between all layers of the MVC in an unfamiliar tech stack.

Another challenge we faced wasn't technical, but planning. We had a decent amount of the services built out, but still had no idea what the final product would look like, resulting in several pivots in the functionality of the program.

### Accomplishments That We're Proud Of
We are proud of finishing The AI Adventure Assistant despite the enormous amount of time spent on project setup alone. We were able to overcome several challenges and deliver a functional and useful program that can generate itineraries based on the user's interests and location.

### What We Learned
We learned the importance of planning ahead before coding and finishing a minimum viable product first. We also gained experience with using a combination of JavaScript, Node.js, and several APIs, as well as implementing the MVC design pattern in an unfamiliar tech stack.

Overall, this project gave everyone exposure to full-stack development, as well as an idea of the challenges faced at each layer.

### What's Next for The AI Adventure Assistant
We have several plans to improve and expand The AI Adventure Assistant. We also plan to add real-time updates to the itinerary based on weather and user feedback. In addition, we plan to include images in the itinerary to provide users with a visual representation of the suggested activities. More features we like to include in the future are:
- Itinerary Editing
- Including Directions
- Including Images
- Opening and closing hours
- Itinerary item rerolling
- New itinerary item rerolling created with the guidance of real-time text completion
- Sharing

### Built With
- ASP.NET Core
- C#
- Open-Meteo
- OpenAI
