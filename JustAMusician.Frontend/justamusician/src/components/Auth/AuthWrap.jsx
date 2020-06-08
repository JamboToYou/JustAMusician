import React from 'react';
import { Redirect } from 'react-router-dom';
import { authorized } from '../../utils/authRequests.js';

class AuthWrap extends React.Component {

	constructor (props) {
		super(props);
		this.state = {
			userAuthorized: false
		}
		this.updateAuth = this.updateAuth.bind(this);
	}

	updateAuth () {
		console.log("we\`re in here");
		authorized((val) => {
			this.setState({ userAuthorized: val }, this.forceUpdate);
		})
	}

	render () {
		if (this.state.userAuthorized)
			return <Redirect to="/" />
		return (
			<div className="container-fluid h-100">
				<div className="row h-100 align-items-center">
					<div className="col-12
							col-sm-10 offset-sm-1
							col-md-8 offset-md-2
							col-lg-6 offset-lg-3
							d-flex
							justify-content-center">
						{<this.props.component updateAuth={this.updateAuth}/>}
					</div>
				</div>
			</div>
		)
	}

}

export default AuthWrap;