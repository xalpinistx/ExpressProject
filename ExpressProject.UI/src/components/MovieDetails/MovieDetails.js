import React from "react";
import { connect } from "react-redux";
import Movie from "../Movie/Movie";

import getMovieById from "../actions/getMovieById";

class MovieDetails extends React.Component {
  componentDidMount() {
    this.props.getMovieById(this.props.match.params.movieId);
  }

  render() {
    if (!this.props.movieById) return <div>Loading...</div>;

    if (this.props.movieById) {
      const { title } = this.props.movieById;

      // const renderMovie = movie => {
      //   return (
      //     <Movie
      //       index={movie.id}
      //       key={movie.id}
      //       movie={movie}
      //       //posterUrls={posterSizes}
      //     />
      //   );
      // };

      return (
        <div>
          <p>{title}</p>
        </div>
      );
    }
  }
}

const mapStateToProps = state => {
  return {
    movieById: state.movie
  };
};

// const mapDispatchToProps = (dispatch) => {
//   return {
//     dispatch(getMovieById);
//   }
// }

export default connect(
  mapStateToProps,
  { getMovieById }
)(MovieDetails);

//export default Movie;
