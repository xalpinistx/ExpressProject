import { combineReducers } from "redux";
import moviesReducer from "./moviesReducer";
//import usersReducer from "./usersReducer";

const MovieApp = combineReducers({
  movies: moviesReducer,
  //usersReducer
});


export default MovieApp;
