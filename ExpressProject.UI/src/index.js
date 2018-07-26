import React from "react";
import ReactDOM from "react-dom";
import Router from "./components/Router";
import { createStore, compose, applyMiddleware } from "redux";
import { Provider } from "react-redux";
import reducers from "./components/reducers/reducer";
import ReduxPromise from "redux-promise";

import "./styles/base_styles/index.css";

const storeWithMiddleware = compose(
  applyMiddleware(ReduxPromise),
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
)(createStore);

// const store = createStore(
//   reducer,
//   window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
// );

ReactDOM.render(
  <Provider store={storeWithMiddleware(reducers)}>
    <Router />
  </Provider>,
  document.getElementById("root")
);
