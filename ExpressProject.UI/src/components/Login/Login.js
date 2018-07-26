import React from "react";
//import { Link } from "react-router-dom";

//import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
//import { faBars } from "@fortawesome/free-solid-svg-icons";

class Login extends React.Component {
  state = {
    isOpen: true
  };

  onHandleClick(e) {}

  render() {
    return (
      <div className="login">
        <button className="login__button" onClick={e => this.onHandleClick(e)}>
          {/* {this.state.isOpen ? <FontAwesomeIcon className="login__icon" icon={faBars} /> : "&times;"} */}
          <span className="login__icon"></span>
          <span className="halflings halflings-remove"></span>
        </button>
      </div>
    );
  }
}

export default Login;
