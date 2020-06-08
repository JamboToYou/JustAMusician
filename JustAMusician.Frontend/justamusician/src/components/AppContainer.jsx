import React from 'react';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';
import { getUser } from '../utils/authRequests.js';

import '../styles/bootstrap.min.css';
import '../styles/style.css';

import App from './App.jsx';
import AuthWrap from './Auth/AuthWrap.jsx';
import AuthRequiredWrap from './Auth/AuthRequiredWrap.jsx';
import LoginWindow from './Auth/LoginWindow.jsx';
import RegisterWindow from './Auth/RegisterWindow.jsx';


class AppContainer extends React.Component {

	constructor (props) {
		super(props);
	}

	render () {
		return (
			<Router>
				<Switch>
					<Route exact path="/register">
						<RegisterWindow />
					</Route>
					<Route path="/login">
						<AuthWrap
							component={LoginWindow}
							/>
					</Route>
					<Route path="/" render={() =>
						<AuthRequiredWrap
							redirectTo="/login"
							orRender={App}/>}/>
				</Switch>
			</Router>
		);
	}

}

export default AppContainer;