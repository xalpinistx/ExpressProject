import React from "react";
import { connect } from "react-redux";
import Movie from "../Movie/Movie";
import { bindActionCreators } from 'redux';

import getTopRatedMovies from "../actions/getTopRatedMovies";

class Movies extends React.Component {
  componentDidMount() {
    this.props.getTopRatedMovies();
  }

  componentDidUpdate() {}

  componentWillUnmount() {}

  render() {
    if (!this.props.topRatedMovies.movies) return <div>Load...</div>;

    if (this.props.topRatedMovies.movies) {
      const {
        movies,
        posterSizes,
        profileSizes,
        totalPages,
        pageNumber,
        totalMovies
      } = this.props.topRatedMovies;

      const renderMovie = movie => {
        return (
          <Movie
            index={movie.id}
            key={movie.id}
            movie={movie}
            posterUrls={posterSizes}
          />
        );
      };

      return (
        <main className="main-movies">
          <section className="main-movies__section">
            <h2 className="main-movies__title text-transform">Top Rated</h2>
            <div className="main-movies__items">{movies.map(renderMovie)}</div>
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

//const mapDispatchToProps = (dispatch) => {
//  return {
//    getTopRatedMovies: function() {
//      return dispatch(getTopRatedMovies())
//    }
//  }
//}

//const mapDispatchToProps = {
//  getTopRatedMovies
//};

const mapDispatchToProps = (dispatch) => {
  return bindActionCreators({
    getTopRatedMovies
  }, dispatch)
}

const TopReatedMovies = connect(
  mapStateToProps,
  mapDispatchToProps
)(Movies);

export default TopReatedMovies;
