import { combineReducers } from "redux";
import moviesReducer from "./moviesReducer";
//import usersReducer from "./usersReducer";

const reducer = combineReducers({
  movies: moviesReducer,
  movie: moviesReducer
  //usersReducer
});


export default reducer;
