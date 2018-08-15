import React, { Fragment } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import Header from "../Header/Header";
import SearchForm from "../Search/Searchform";
import Footer from "../Footer/Footer";
import dateformat from "dateformat";

import { PieChart } from "react-easy-chart";

import getMovieById from "../actions/getMovieById";

class MovieDetails extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      creators: this.props.getMovieById(this.props.match.params.movieId)
        .MovieCredit
    };
  }

  componentDidMount() {
    this.props.getMovieById(this.props.match.params.movieId);
    // const creators = this.props
    //   .getMovieById(this.props.match.params.movieId)
    //   .MovieCredit.crew.slice(0, 5);
    //this.setState({ creators });
  }

  render() {
    if (!this.props.movieById || !this.props.movieById.PosterSizes)
      return <div>Loading...</div>;
    else {
      const {
        Movie: {
          id,
          title,
          overview,
          release_date,
          original_title,
          vote_average,
          backdrop_path,
          poster_path
        },
        MovieCredit: { crew, cast },
        PosterSizes,
        ProfileSizes,
        BackDropSizes
      } = this.props.movieById;

      const backdropImage = BackDropSizes[3] + backdrop_path;
      const mainCrew = crew.slice(0, 6);

      const styles = {
        header: {
          backgroundImage: `url(${backdropImage})`,
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
          backgroundSize: "cover"
        },

        content: {
          height: "100%",
          width: "100%",
          backgroundColor: "rgba(79, 79, 79, 0.7)"
        }
      };

      return (
        <Fragment>
          <Header />
          <SearchForm />
          <main className="movie-details" style={styles.header}>
            <div
              className="movie-details__background-wrapper"
              style={styles.content}
            >
              <section className="movie-details__section">
                <div class="movie-details__poster">
                  <Link to={`/movies/${id}`} className="main-movies__item-link">
                    <img
                      className="movie-details__item-img"
                      src={PosterSizes[4] + poster_path}
                      alt={id}
                    />
                  </Link>
                </div>
                <div className="movie-details__desc">
                  <div className="movie-details__title">
                    <Link
                      to={`/movies/${id}`}
                      className="movie-details__item-link"
                    >
                      <h2 class="movie-details__movie-title space">{title}</h2>
                    </Link>
                    <span className="movie-details__movie-date">
                      ({dateformat(release_date, "yyyy")})
                    </span>
                  </div>
                  <div className="movie-details__original-title">
                    <h2 className="movie-details__movie-title space">
                      {original_title}
                    </h2>
                    <h2 className="movie-details__movie-title font-style">
                      (original title)
                    </h2>
                  </div>
                  <ul className="movie-details__movie-handlers">
                    <li>
                      <div className="movie-details__chart">
                        <PieChart
                          size={70}
                          innerHoleSize={40}
                          labels
                          data={[
                            {
                              key: "",
                              value: vote_average * 10,
                              color: "#01d277"
                            },
                            {
                              key: "",
                              value: 100 - vote_average * 10,
                              color: "#081c24"
                            }
                          ]}
                          styles={{
                            ".chart_text": {
                              fontSize: "0.5rem",
                              fill: "#fff"
                            }
                          }}
                        />
                      </div>
                      <div className="movie-details__score">
                          <p className="movie-details__score-number">{vote_average}</p>
                      </div>
                    </li>
                  </ul>
                  <div className="movie-details__movie-info">
                    <h3>Overview</h3>
                    <div className="movie-details__movie-overview">
                      <p>{overview}</p>
                    </div>
                    <h3 class="movie-details__featured">Featured Crew</h3>
                    <ol className="movie-details__crew">
                      {mainCrew.map(creator => (
                        <li className="movie-details__crew__member">
                          <p className="movie-details__font-bold">
                            {creator.name}
                          </p>
                          <p>{creator.job}</p>
                        </li>
                      ))}
                    </ol>
                  </div>
                </div>
              </section>
            </div>
          </main>
          <Footer />
        </Fragment>
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
