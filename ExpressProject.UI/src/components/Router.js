import React from "react";
import { Switch, Route, BrowserRouter } from "react-router-dom";
import App from "./App";
import Movie from "./Movie/Movie";
import Login from './Login/Login';

export default () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={App} />
        <Route path="/movie/" component={Movie} />
        <Route path="/login" component={Login}/>
      </Switch>
    </BrowserRouter>
  );
};
