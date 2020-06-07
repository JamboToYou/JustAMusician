import React from 'react'
import { Link } from 'react-router-dom';

class Navbar extends React.Component {

	constructor(props) {
		super(props);
	}

	render() {
		return (
			<nav className="navbar navbar-expand-lg navbar-dark bg-dark jam-navbar">
				<Link className="navbar-brand" to="/app">JAM</Link>
				<button className="navbar-toggler"
						type="button"
						data-toggle="collapse"
						data-target="#navbarSupportedContent"
						aria-controls="navbarSupportedContent"
						aria-expanded="false"
						aria-label="Toggle navigation"> <span className="navbar-toggler-icon"></span>
				</button>

				<div className="collapse navbar-collapse" id="navbarSupportedContent">
					<ul className="navbar-nav mr-auto">

						<li className="nav-item">
							<Link className="nav-link" to="/app/lobby">Заявки</Link>
						</li>

						<li className="nav-item">
							<Link className="nav-link"
								  to="/app/profile">Профиль
							</Link>
						</li>
					</ul>
					<form className="form-inline my-2 my-lg-0">
						<input className="form-control mr-sm-2"
							   type="search"
							   placeholder="Поиск"
							   aria-label="Search" />
						<Link className="btn btn-outline-success my-2 my-sm-0"
								to="/app/search">Искать
						</Link>
					</form>
				</div>
			</nav>
		);
	}

}

export default Navbar;
