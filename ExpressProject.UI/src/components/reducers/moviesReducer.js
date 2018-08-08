import movie from "./movieReducer";

const movies = (state = {}, action) => {
  switch (action.type) {
    case "ADD_MOVIE":
      return [...state, movie(state, action)];

    case "GET_TOP_RATED_MOVIES":
      console.log(action);
      console.log(state);
      return {
        movies: action.payload.Movies,
        totalPages: action.payload.TotalPages,
        pageNumber: action.payload.PageNumber,
        totalMovies: action.payload.TotalMovies,
        posterSizes: action.payload.PosterSizes
      };

    case "GET_MOVIE_BY_ID":
      console.log(action);
      console.log(state);
      if (state.id !== action.id) return state;
      return action.payload;

    case "GET_MOVIES":
      return state;

    case "UPDATE_MOVIE":
      if (state.id !== action.id) return state;
      return {
        release: action.release
        //
      };

    case "DELETE_MOVIE":

    default:
      return state;
  }
};

export default movies;
