import React from 'react';

class AuthWrap extends React.Component {

	constructor (props) {
		super(props);
	}

	render () {
		return (
			<div className="container-fluid h-100">
				<div className="row h-100 align-items-center">
					<div className="col-12
							col-sm-10 offset-sm-1
							col-md-8 offset-md-2
							col-lg-6 offset-lg-3
							d-flex
							justify-content-center">
						{this.props.children}
					</div>
				</div>
			</div>
		)
	}

}

export default AuthWrap;