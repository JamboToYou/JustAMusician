import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

import Navbar from './Navbar/Navbar.jsx';
import MainPage from './Body/MainPage.jsx';
import Footer from './Footer.jsx';
import Lobby from './Lobby/Lobby.jsx';
import Profile from './Profile/Profile.jsx';

const mockData = [
	{
		title: "Ищем басиста",
		body: "В панк-рок группу требуется басист. Наш основной репертуар выходит на груве басовой линии, и поэтому важен скилл",
		username: "rinat"
	},
	{
		title: "Требуется экстрим-вокалист",
		body: "Нужен для 3-4 студийных сессий. Материал имеется. Есть демо-записи прошлого вокалиста",
		username: "alexander95"
	},
	{
		title: "Набор гитаристов в ансамбль",
		body: "Есть 13 мест, 7 из них на нейлоне, 4 на аккустике и 2 на баритон. Играем нео-классику",
		username: "lilovaya_polosa"
	},
	{
		title: "Ищу звукача",
		body: "Требуется на выезд. Оборудование свое. Подробности в лс",
		username: "ramjam"
	},
	{
		title: "!!!СРОЧНО!!!Басист!!!",
		body: "Срочно!!! Ищем басиста для 4-хконцертного тура. Материал простой, так что достаточно пройти у нас небольшой кастинг. подробности по гонорару при встрече",
		username: "thread_roast"
	}
];

const searchData = [
	{
		title: "Ищем басиста",
		body: "В панк-рок группу требуется басист. Наш основной репертуар выходит на груве басовой линии, и поэтому важен скилл",
		username: "rinat"
	},
	{
		title: "Требуется экстрим-вокалист",
		body: "Нужен для 3-4 студийных сессий. Материал имеется. Есть демо-записи прошлого вокалиста",
		username: "alexander95"
	},
	{
		title: "!!!СРОЧНО!!!Басист!!!",
		body: "Срочно!!! Ищем басиста для 4-хконцертного тура. Материал простой, так что достаточно пройти у нас небольшой кастинг. подробности по гонорару при встрече",
		username: "thread_roast"
	}
];

class App extends React.Component {

	constructor(props) {
		super(props);
	}

	render() {
		return (
			<Router>
				<div>
					<div className="container-fluid">
						<Navbar />
						<div className="row jam-body-container">
							<Switch>
								<Route exact path="/" component={MainPage} />
								<Route path="/lobby" component={() => <Lobby orders={mockData} />} />
								<Route path="/search" component={() => (
									<Lobby orders={searchData}>
										<p className="display-4 text-success">Результаты поиска</p>
									</Lobby>)} />
								<Route path="/profile" component={Profile} />
							</Switch>
						</div>
					</div>
					<Footer />
				</div>
			</Router>
		);
	}

}

export default App;