import React, { Component, Fragment } from "react";



import Header from "./Header/Header";
import SearchForm from "./Search/Searchform";
import Movies from "./Movies/Movies";
import Footer from "./Footer/Footer";


class App extends Component {
  constructor(props) {
    super(props);
  }



  render() {
    return (
      <Fragment>
        <div className="fixed-container ">
          <Header />
          <SearchForm />
        </div>
        <Movies />
        <Footer />
      </Fragment>
    );
  }
}

export default App;
