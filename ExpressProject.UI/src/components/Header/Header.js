import React from "react";
import { Link } from "react-router-dom";
import Login from "../Login/Login";

const Header = () => {
  return (
    <div className="gray-wrapper black-shadow-wrapper">
      <header className="moviecrew-header">
        <div className="moviecrew-header__logo-wrapper">
          <img
            className="moviecrew-header__logo"
            src="https://www.themoviedb.org/assets/1/v4/logos/powered-by-rectangle-green-dcada16968ed648d5eb3b36bbcfdd8cdf804f723dcca775c8f2bf4cea025aad6.svg"
            alt=""
          />
        </div>
        <nav className="moviecrew-header__nav-tab">
          <ul className="moviecrew-header__list">
            <li className="moviecrew-header__list-item">
              <Link to="/Discover">Discover</Link>
            </li>
            <li className="moviecrew-header__list-item">
              <Link to="/Movies">Movies</Link>
            </li>
            <li className="moviecrew-header__list-item">
              <Link to="/TVShows">TV Shows</Link>
            </li>
          </ul>
        </nav>
        <Login/>
      </header>
    </div>
  );
};

export default Header;
