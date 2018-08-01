import React, { Fragment } from "react";

const Movie = ({ index, movie }) => {
  const { adult, poster_path, backdrop_path, title, overview } = movie;
  return (
    <div className="main-movies__item">
      <h3 className="main-movies__item-title">{title}</h3>
      <a href="">
        <img
          className="main-movies__item-img"
          src={poster_path}
          alt={title}
        />
      </a>
      <p className="main-movies__desc">{overview}</p>
    </div>
  );
};

export default Movie;
