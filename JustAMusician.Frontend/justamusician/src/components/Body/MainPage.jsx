import React from 'react';

const MainPage = () => {
	return (
		<div className="jumbotron jumbotron-fluid w-100 bg-light" id="jam-main-intro">
			<div className="container jam-main-intro-content">
				<p className="display-4">JustAMusician</p>
				<div className="jumbotron jumbotron-fluid w-100 bg-light">
					<p className="lead pl-5">Сервис JustAMusician - это веб-портал, который помогает музыкантам искать
						музыкальные коллективы в соответствии со своими вкусами, творческим стилем и жанром. Таким
						же способом музыкальные коллективы смогут пополнить свои ряды единомышленниками.</p>
				</div>
			</div>
			<div className="container" id="jam-you-can">В нашем сервисе Вы найдете:</div>
			<div className="container jam-main-intro-content">
				<div className="row">
					<div className="col-4 pl-2 pr-2">
						<div className="card bg-info">
							<div className="card-body">
								<div className="card-title display-4">Поиск музыкантов</div>
								<p className="card-text">Some quick example text to build on the card title and make up
									the
									bulk of the card's content.</p>
								<a className="btn btn-primary text-light">Перейти</a>
							</div>
						</div>
					</div>
					<div className="col-4 pl-2 pr-2">
						<div className="card bg-info">
							<div className="card-body">
								<div className="card-title display-4">Личное портфолио</div>
								<p className="card-text">Some quick example text to build on the card title and make up
									the
									bulk of the card's content.</p>
								<a className="btn btn-primary text-light">Перейти</a>
							</div>
						</div>
					</div>
					<div className="col-4 pl-2 pr-2">
						<div className="card bg-info">
							<div className="card-body">
								<div className="card-title display-4">Заголовок</div>
								<p className="card-text">Some quick example text to build on the card title and make up
									the
									bulk of the card's content.</p>
								<a className="btn btn-primary text-light">Перейти</a>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	);
}

export default MainPage;