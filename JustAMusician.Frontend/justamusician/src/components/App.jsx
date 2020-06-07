import React from 'react';
import { Switch, Route, useRouteMatch } from 'react-router-dom';

import Navbar from './Navbar/Navbar.jsx';
import MainPage from './Body/MainPage.jsx';
import Footer from './Footer.jsx';
import Lobby from './Lobby/Lobby.jsx';
import Profile from './Profile/Profile.jsx';
import Search from './Search/Search.jsx';

class App extends React.Component {

	constructor(props) {
		super(props);
	}

	render() {

		return (
			<div>
				<div className="container-fluid">
					<Navbar />
					<div className="row jam-body-container">
						<div className="container-fluid row">
							<div className="col-md-3 col-lg-2" id="jam-sidebar-container">
								<div className="list-group">
									<a href="#" className="bg-warning list-group-item list-group-item-action disabled">Бенд-треды</a>
									<a href="#" className="bg-warning list-group-item list-group-item-action">Группы</a>
									<a href="#" className="bg-warning list-group-item list-group-item-action">Сессии</a>
									<a href="#" className="bg-warning list-group-item list-group-item-action">Концерты</a>
									<a href="#" className="bg-warning list-group-item list-group-item-action">Разработка материала</a>
								</div>
							</div>
							<div className="col-md-9 col-lg-10 jumbotron mr-0 w-100 bg-light p-4" id="jam-main-intro">
								<Route exact path="/app" component={MainPage} />
								<Route path="/app/lobby" component={() => <Lobby />} />
								<Route path="/app/search" component={Search} />
								<Route path="/app/profile" component={Profile} />
							</div>
						</div>
					</div>
				</div>
				<Footer />
			</div>
		);
	}

}

export default App;