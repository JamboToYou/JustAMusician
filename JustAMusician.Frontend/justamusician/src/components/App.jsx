import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

import Navbar from './Navbar/Navbar.jsx';
import MainPage from './Body/MainPage.jsx';
import Footer from './Footer.jsx';
import Lobby from './Lobby/Lobby.jsx';

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
								<Route path="/lobby" component={Lobby} />
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