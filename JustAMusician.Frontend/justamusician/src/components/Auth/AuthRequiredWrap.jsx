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

		authorized((val) => 
		{
			this.setState({ userAuthorized: val });
		})
	}

	render() {
		if(!this.state.userAuthorized) {
			return(<Redirect to={this.state.redirectTo} /> );
		} else {
			return (this.props.orRender);
		}
	}
}

export default AuthRequiredWrap;