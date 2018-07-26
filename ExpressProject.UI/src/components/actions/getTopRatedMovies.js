import axios from "axios";

const routePrefix = "movie";
const route = "getTopRatedMovies";
const url = `http://localhost:56954/${routePrefix}/${route}`;

const getTopRatedMovies = () => {
  const request = axios
    .get(url)
    .then(response => {
      return response.data;
    })
    .catch(error => errorInRequest(error));

  return {
    type: "GET_TOP_RATED_MOVIES",
    payload: request
  };
};

function errorInRequest(error) {
  if (error.response) {
    // The request was made and the server responded with a status code
    // that falls out of the range of 2xx
    console.log(error.response.data);
    console.log(error.response.status);
    console.log(error.response.headers);
  } else if (error.request) {
    // The request was made but no response was received
    // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
    // http.ClientRequest in node.js
    console.log(error.request);
  } else {
    // Something happened in setting up the request that triggered an Error
    console.log(`Error: ${error.message}`);
  }
  console.log(error.config);
}

// function getTopRatedMovies() {
//   return {
//     type: "GET_MOVIE",
//     payload: payload
//   };
// }

export default getTopRatedMovies;
