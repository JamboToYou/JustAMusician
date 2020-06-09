import React from 'react';
import { Redirect } from 'react-router-dom';
import { authorized } from '../../utils/authRequests.js';

export class AuthRequiredWrap extends React.Component {
	constructor(props) {

		super(props);
		this.state = {
			redirectTo: props.redirectTo,
			userAuthorized: true
		};
		this.handleLogout = this.handleLogout.bind(this);
	}

	componentDidMount() {
		this.setState({ userAuthorized: authorized() });
	}

	handleLogout() {
		this.setState({ userAuthorized: authorized() });
	}

	render() {
		if(!this.state.userAuthorized) {
			return (<Redirect to={this.state.redirectTo} /> );
		} else {
			return (<this.props.orRender logout={this.handleLogout}/>);
		}
	}
}

export default AuthRequiredWrap;