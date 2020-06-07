import React from 'react';
import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';

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
						<AuthWrap>
							<RegisterWindow />
						</AuthWrap>
					</Route>
					<Route exact path="/">
						<AuthWrap>
							<LoginWindow />
						</AuthWrap>
					</Route>
					<Route path="/app" render={() =>
						<AuthRequiredWrap
							redirectTo="/"
							orRender={ <App /> }/>}/>
				</Switch>
			</Router>
		);
	}

}

export default AppContainer;