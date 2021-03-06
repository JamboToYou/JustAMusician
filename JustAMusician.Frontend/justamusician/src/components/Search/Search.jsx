import React from 'react';
import { Redirect, Link } from 'react-router-dom';
import $ from 'jquery';
import CheckboxTree from 'react-checkbox-tree';
import DateRangePicker from 'react-bootstrap-daterangepicker';
import 'react-checkbox-tree/lib/react-checkbox-tree.css';
import 'bootstrap-daterangepicker/daterangepicker.css';
import './search-style.css';
import { normalizeNodes, isNullOrWhitespace } from '../../utils/utils.js';
import { getGenres, getInstruments } from '../../utils/authRequests.js';

const nodes = [
	{
		value: '1',
		label: 'Mars',
		children: [
			{ value: 'phobos', label: 'Phobos' },
			{ value: 'deimos', label: 'Deimos' },
		],
	},
	{
		value: '2',
		label: 'Mars',
		title: 'eete',
		children: [
			{ value: 'cratos', label: 'Phobos' },
			{ value: 'dains', label: 'Deimos' },
		],
	},
	{
		value: '3',
		label: 'Mars',
		children: [
			{ value: 'jojojo', label: 'Phobos' },
			{ value: 'bastard', label: 'Deimos' },
		],
	}
];

const genreIcons = {
	check: <span className="rct-icon rct-icon-check" />,
	uncheck: <span className="rct-icon rct-icon-uncheck" />,
	halfCheck: <span className="rct-icon rct-icon-half-check" />,
	expandClose: <span className="rct-icon rct-icon-expand-close" />,
	expandOpen: <span className="rct-icon rct-icon-expand-open" />,
	expandAll: <span className="rct-icon rct-icon-expand-all" />,
	collapseAll: <span className="rct-icon rct-icon-collapse-all" />,
	parentClose: <span className="fas fa-music" />,
	parentOpen: <span className="fal fa-music" />,
	leaf: <span className="fas fa-music" />,
};

const instrumentIcons = {
	check: <span className="rct-icon rct-icon-check" />,
	uncheck: <span className="rct-icon rct-icon-uncheck" />,
	halfCheck: <span className="rct-icon rct-icon-half-check" />,
	expandClose: <span className="rct-icon rct-icon-expand-close" />,
	expandOpen: <span className="rct-icon rct-icon-expand-open" />,
	expandAll: <span className="rct-icon rct-icon-expand-all" />,
	collapseAll: <span className="rct-icon rct-icon-collapse-all" />,
	parentClose: <span className="fas fa-guitar" />,
	parentOpen: <span className="fal fa-guitar" />,
	leaf: <span className="fas fa-guitar" />,
};

class Search extends React.Component {

	constructor(props) {
		super(props);
		this.datePickHandler = this.datePickHandler.bind(this);
		this.submitHandler = this.submitHandler.bind(this);

		this.state = {

			genres: props.genres,
			instruments: props.instruments,
			genresExpanded: [],
			instrumentsExpanded: [],

			instrumentsChecked: [],
			genresChecked: [],
			startDate: null,
			endDate: null,
			isLeader: false,
		}
	}

	datePickHandler (event, picker) {
		this.setState({
			startDate: picker.startDate.format("YYYY-MM-DD[T00:00:00]"),
			endDate: picker.endDate.format("YYYY-MM-DD[T00:00:00]")
		});
	}

	submitHandler (event) {
		const rqData = {
			genres: this.state.genresChecked,
			instruments: this.state.instrumentsChecked,
			startDate: this.state.startDate,
			endDate: this.state.endDate,
		};

		console.log(rqData);
		return <Redirect to="/" />;
	}

	render() {
		return (
			<div className="container">
				<p className="text-success" id="jam-search-title">Поиск заявок</p>
				<div className="jumbotron">
					<div className="row ml-3 mb-3">
						<div className="form-check form-check-inline">
							<input
								className="form-check-input"
								type="radio"
								name="inlineRadioOptions"
								id="isMusicianRadio"
								value="isMusician" />
							<label className="form-check-label" htmlFor="isMusician">Музыкант</label>
						</div>
						<div className="form-check form-check-inline">
							<input
								className="form-check-input"
								type="radio"
								name="inlineRadioOptions"
								id="isBandRadio"
								value="isBand" disabled={this.state.isLeader}/>
							<label className="form-check-label" htmlFor="isBand">Группа</label>
						</div>
					</div>

					<div className="row">
						<div className="col-12 col-lg-6 mb-2">
							<div className="card jam-search-tree">
								<CheckboxTree
									nodes={this.state.genres}
									checked={this.state.genresChecked}
									checkModel={"all"}
									expanded={this.state.genresExpanded}
									onCheck={checked => this.setState({ genresChecked: checked })}
									onExpand={expanded => this.setState({ genresExpanded: expanded })}
									iconsClass={"fa5"}
									icons={genreIcons}
								/>
							</div>
						</div>
						<div className="col-12 col-lg-6 mb-2">
							<div className="card jam-search-tree">
								<CheckboxTree
									nodes={this.state.instruments}
									checked={this.state.instrumentsChecked}
									checkModel={"all"}
									onlyLeafCheckboxes
									expanded={this.state.instrumentsExpanded}
									onCheck={checked => this.setState({ instrumentsChecked: checked })}
									onExpand={expanded => this.setState({ instrumentsExpanded: expanded })}
									iconsClass={"fa5"}
									icons={instrumentIcons}
								/>
							</div>
						</div>
					</div>

					<div className="row mt-3">
						<div className="col-12 col-lg-6 mb-2">

							<div className="card">
								<DateRangePicker onEvent={this.datePickHandler}>
									<div className="card-header">
										{ this.state.startDate ? this.state.startDate + "/": "Кликните сюда, чтобы выбрать даты" }
										{ this.state.endDate ? this.state.endDate : "" }
									</div>
								</DateRangePicker>
								<div className="card-body">
									<p>Сортировать по:</p>
									<div className="form-check form-check-inline">
										<input
											className="form-check-input"
											type="radio"
											name="sortOptions"
											id="sortByDateUpper" value="option1" />
										<label className="form-check-label" htmlFor="sortByDateUpper">Новые</label>
									</div>
									<div className="form-check form-check-inline">
										<input
											className="form-check-input"
											type="radio"
											name="sortOptions"
											id="sortByDateLower"
											value="option2" />
										<label className="form-check-label" htmlFor="sortByDateLower">Старые</label>
									</div>
								</div>
							</div>
						</div>
						{/*<div className="col-12 col-lg-6 mb-2">

							<p className="card-title">Теги</p>

							<ul className="list-group list-group-flush">
								{this.state.selectedTags.map((tag, idx) =>
									<li className="list-group-item" key={idx}>{tag}</li>
								)}
								<input type="text" className="form-control" onChange={this.tagInputHandler} placeholder="Добавьте желаемые теги" />
							</ul>

						</div>*/}
					</div>

					<div className="row mt-3">
						<div className="col-12 ">
							<button type="button" className="btn btn-danger mr-3">Сбросить</button>
							<Link
								to={{
									pathname: "/searchResults",
									state: {
										Genres: this.state.genresChecked,
										Instruments: this.state.instrumentsChecked,
										StartDate: this.state.startDate,
										EndDate: this.state.endDate,
									}
								}}
								onClick={this.submitHandler}
								className={"btn btn-info " + ((isNullOrWhitespace(this.state.startDate) ||
										isNullOrWhitespace(this.state.endDate))
										? "disabled"
										: "" )}>Искать</Link>
						</div>
					</div>

				</div>
			</div>
		);
	}

}

export default Search;