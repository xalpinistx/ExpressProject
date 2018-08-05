import React, { Component, Fragment } from "react";
import Header from "./components/Header/Header";
import SearchForm from "./components/Search/Searchform";
import Movies from "./components/Movies/Movies";
import Footer from './components/Footer/Footer';

class App extends Component {
  constructor(props) {
    super(props);
  }



  render() {
    return (
      <Fragment>
        <div className="fixed-container ">
          <Header/>
          <SearchForm />
        </div>
        <Movies />
        <Footer/>
      </Fragment>
    );
  }
}

export default App;
