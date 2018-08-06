import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHeart } from "@fortawesome/free-solid-svg-icons";

<<<<<<< HEAD
const Movie = ({ index, movie, posterUrls }) => {
  const { adult, poster_path, backdrop_path, title, overview } = movie;
=======
import niceParagraph from "../helpers/nicerParagraph";

import { PieChart } from "react-easy-chart";
import dateformat from "dateformat";

const Movie = ({ index, movie, urls }) => {
  const { poster_path, title, overview, vote_average, release_date } = movie;
>>>>>>> e58da88293821d9ea23f98052eca069abcc037e7
  return (
    <div className="main-movies__item">
      <div className="main-movies__item-img-content">
        <a href="" className="main-movies__item-link">
          <img
            className="main-movies__item-img"
            src={poster_path}
            alt={title}
          />
        </a>
      </div>
      <div className="main-movies__item-desc-content">
        <Link
          to={`/movies/${title}`}
          className="main-movies__item-title text-transform text-center"
        >
          {title}
        </Link>
        <span className="main-movies__item-date">
          {dateformat(release_date, "mmmm dd, yyyy")}
        </span>
        <p className="main-movies__item-desc">{niceParagraph(overview)}</p>
        <div className="main-movies__item-more ">
          <span className="cursor-pointer">More info</span>
        </div>
        <div className="main-movies__item-vote show-vote-absolute">
          <FontAwesomeIcon
            className="main-movies__item-vote-heart"
            icon={faHeart}
          />
          {/* <span className="main-movies__item-vote-average voite-chart">
            {vote_average}
          </span> */}
          <PieChart
            size={40}
            labels
            data={[
              { key: '', value: 100, color: "#aaac84" },
              { key: `${vote_average}`, value: vote_average * 10, color: "#e3a51a" }
            ]}
            styles={{
              ".chart_text": {
                fontSize: "0.5rem",
                fill: "#fff"
              }
            }}
          />
        </div>
      </div>
      <h3 className="main-movies__item-title">{title}</h3>
      <a href="">
        <img
          className="main-movies__item-img"
          src={posterUrls[4] + poster_path}
          alt={title}
        />
      </a>
      <p className="main-movies__desc">{overview}</p>
    </div>
  );
};

export default Movie;
