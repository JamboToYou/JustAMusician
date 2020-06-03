import React from 'react'
import { Link } from 'react-router-dom';

class Navbar extends React.Component {

	constructor(props) {
		super(props);
	}

	render() {
		return (
			<nav className="navbar navbar-expand-lg navbar-dark bg-dark jam-navbar">
				<Link className="navbar-brand" to="/">JAM</Link>
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
							<Link className="nav-link" to="/lobby">Заявки</Link>
						</li>

						<li className="nav-item dropdown">
							<a className="nav-link dropdown-toggle"
							   href="#"
							   id="navbarDropdown"
							   role="button"
							   data-toggle="dropdown"
							   aria-haspopup="true"
							   aria-expanded="false">Категории
							</a>
							<div className="dropdown-menu" aria-labelledby="navbarDropdown">
								<a className="dropdown-item" href="#">Action</a>
								<a className="dropdown-item" href="#">Another action</a>
								<div className="dropdown-divider"></div>
								<a className="dropdown-item" href="#">Something else here</a>
							</div>
						</li>

						<li className="nav-item">
							<Link className="nav-link"
								  to="profile">Профиль
							</Link>
						</li>
					</ul>
					<form className="form-inline my-2 my-lg-0">
						<input className="form-control mr-sm-2"
							   type="search"
							   placeholder="Поиск"
							   aria-label="Search" />
						<Link className="btn btn-outline-success my-2 my-sm-0"
								to="/search">Искать
						</Link>
					</form>
				</div>
			</nav>
		);
	}

}

export default Navbar;
