import axios from "axios";

const routePrefix = "movie";
const route = "getMovieById";
const host = "localhost:56954";
const url = `http://${host}/${routePrefix}/${route}`;

function getMovieById(id) {
  const request = axios
    .get(`${url}/${id}`)
    .then(response => {
      return response.data;
    })
    .catch(error => errorInRequest(error));

  return {
    type: "GET_MOVIE_BY_ID",
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

export default getMovieById;
