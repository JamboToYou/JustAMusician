import React from 'react';
import { Link, Switch, Route, useRouteMatch } from 'react-router-dom';
import { normalizeNodes } from '../utils/utils.js';
import { getUser, getGenres, getInstruments } from '../utils/authRequests.js';

import Navbar from './Navbar/Navbar.jsx';
import MainPage from './Body/MainPage.jsx';
import Footer from './Footer.jsx';
import Lobby from './Lobby/Lobby.jsx';
import Profile from './Profile/Profile.jsx';
import Search from './Search/Search.jsx';
import CreateOrder from './Order/CreateOrder.jsx';
import AuthRequiredWrap from './Auth/AuthRequiredWrap.jsx'
import Order from './Order/Order.jsx'

class App extends React.Component {

	constructor(props) {
		super(props);
		this.state = {
			user: {
				nickname: "",
				email: "",
				links: [],
				about: "",
				userId: "",
				bands: [],
				signedUpAt: "",
				genres: [],
				instruments: []
			},
			genres: [],
			instruments: []
		}
	}

	componentDidMount() {
		getUser(
			(data, status, xhr) => {
				console.log(data);
				this.setState({
					user: {
						nickname: data.nickname,
						email: data.email,
						about: data.about,
						links: data.links,
						userId: data.userId,
						bands: data.bands,
						signedUpAt: data.signedUpAt,
						genres: data.genres,
						instruments: data.instruments
					}
				});
			},
			(xhr, errorData, errorThrown) => {
				console.log("--==user fail==--");
				console.log(xhr);
				console.log(errorData);
				console.log(errorThrown);
				console.log("--==user fail==--");
			}
		);

		getGenres(
			(data, textStatus, xhr) => {
				this.setState({ genres: normalizeNodes(data) });
			},
			(xhr, errData, errThrown) => {}
		);
		getInstruments(
			(data, textStatus, xhr) => {
				data.sort((a, b) =>
				{
					if (a.label > b.label)
						return 1;
					if (a.label < b.label)
						return -1;
					return 0;
				});

				this.setState({ instruments: data });
			},
			(xhr, errData, errThrown) => {}
		);
	}

	render() {

		return (
			<div>
				<div className="container-fluid">
					<Navbar logout={this.props.logout} />
					<div className="row jam-body-container">
						<div className="container-fluid row">
							<div className="col-md-3 col-lg-2" id="jam-sidebar-container">
								<div className="list-group">
									<Link to="/orderCreate" className="list-group-item list-group-item-action">Создать заявку</Link>
									<a href="#" className="list-group-item list-group-item-action">Группы</a>
									<a href="#" className="list-group-item list-group-item-action">Сессии</a>
									<a href="#" className="list-group-item list-group-item-action">Концерты</a>
									<a href="#" className="list-group-item list-group-item-action">Разработка материала</a>
								</div>
							</div>
							<div className="col-md-9 col-lg-10 jumbotron mr-0 w-100 bg-light p-4" id="jam-main-intro">
								<Route exact path="/" component={() =>
									<AuthRequiredWrap
										redirectTo="/login"
										orRender={MainPage}/>} />
								<Route path="/lobby" component={() => <Lobby />} />
								<Route path="/search" component={() =>
									<Search
										genres={this.state.genres}
										instruments={this.state.instruments}
										user={this.state.user}/>} />
								<Route path="/profile" component={() => <Profile user={this.state.user} />} />
								<Route path="/orderCreate" component={() =>
									<CreateOrder
										genres={this.state.genres}
										instruments={this.state.instruments}
										user={this.state.user}/>} />
								<Route path="/order/:id" component={Order} />
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