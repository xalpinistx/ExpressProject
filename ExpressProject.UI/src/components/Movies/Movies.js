import React from "react";
import { connect } from "react-redux";
import Movie from "../Movie/Movie";

import getTopRatedMovies from ".././actions/getTopRatedMovies";

class Movies extends React.Component {
  componentDidMount() {
    this.props.getTopRatedMovies();
  }

  render() {
    if (!this.props.topRatedMovies.movies) return <div>Load...</div>;

    if (this.props.topRatedMovies.movies) {
      const { movies } = this.props.topRatedMovies;
      //console.log(this.props.topRatedMovies.movies[0].original_title);
      return (
        <main className="main-movies">
          <section className="main-movies__section">
            <h2 className="main-movies__title">Top Rated</h2>
              {movies.map(movie => {
                return <Movie index={movie.id} key={movie.id} movie={movie} />;
              })}
          </section>
          {/* <section className="main-movies__section">
            <h2 className="main-movies__title">Most viewed</h2>
            <div className="main-movies__item">
              <img
                className="main-movies__item-img"
                src="https://image.tmdb.org/t/p/w600_and_h900_bestv2/3gIO6mCd4Q4PF1tuwcyI3sjFrtI.jpg"
                alt="rampage"
              />
            </div>
          </section> */}
        </main>
      );
    }
  }
}

const mapStateToProps = (state, ownProps) => {
  return {
    topRatedMovies: state.movies
  };
};

const TopReatedMovies = connect(
  mapStateToProps,
  { getTopRatedMovies }
)(Movies);

export default TopReatedMovies;
