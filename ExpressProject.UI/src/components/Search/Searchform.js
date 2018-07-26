import React from "react";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSearch } from "@fortawesome/free-solid-svg-icons";

class SearchForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      term: "",
      isSearch: false
    };
  }

  onHandleChange = event => {
    const term = event.target.value;
    this.setState({ term });
    this.setState({ term, isSearch: !this.state.isSearch });
  };

  render() {
    return (
      <div className="search-form">
        <FontAwesomeIcon
          icon={faSearch}
          className={
            !this.state.isSearch ? "search-form__icon" : "display-none"
          }
        />
        <input
          className="search-form__search"
          type="text"
          value={this.state.term}
          onChange={this.onHandleChange}
        />
      </div>
    );
  }
}

export default SearchForm;
