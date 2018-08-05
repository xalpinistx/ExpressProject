import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHeart } from "@fortawesome/free-solid-svg-icons";

import niceParagraph from "../helpers/nicerParagraph";

import { PieChart } from "react-easy-chart";
import dateformat from "dateformat";

const Movie = ({ index, movie, urls }) => {
  const { poster_path, title, overview, vote_average, release_date } = movie;
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
    </div>
  );
};

export default Movie;
