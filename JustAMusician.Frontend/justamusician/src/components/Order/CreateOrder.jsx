import React from 'react';
import { Redirect } from 'react-router-dom';
import CheckboxTree from 'react-checkbox-tree';
import $ from 'jquery';
import { addOrder } from '../../utils/authRequests.js';
import { isNullOrWhitespace } from '../../utils/utils.js';
import './createOrder-style.css';

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

class CreateOrder extends React.Component {

	constructor(props) {
		super(props);

		this.submitHandler = this.submitHandler.bind(this);
		this.inputHandler = this.inputHandler.bind(this);
		this.validateField = this.validateField.bind(this);
		this.validateForm = this.validateForm.bind(this);

		this.state = {
			isTitleValid: 0,
			isBodyValid: 0,

			addingSuc: false,

			genres: props.genres,
			instruments: props.instruments,
			genresExpanded: [],
			instrumentsExpanded: [],

			instrumentsChecked: [],
			genresChecked: [],
			title: "",
			body: "",
			forBand: false,

			isLeader: false,
		}
	}

	submitHandler (event) {
		event.preventDefault();
		if (this.state.valid) {
			addOrder(
				JSON.stringify({
					Title: this.state.title,
					Body: this.state.body,
					Genres: this.state.genresChecked,
					Instruments: this.state.instrumentsChecked,
					ForBand: this.state.forBand
				}),
				(data, status, xhr) => {
					this.setState({ addingSuc: true })
				},
				(x, y, z) => {}
			);
		}
	}

	inputHandler (e) {
		const name = e.target.name;
		const value = e.target.value;
		this.setState({[name]: value}, 
			() => { this.validateField(name, value) });
	}

	validateField(fieldName, value) {
		let titleValid = this.state.isTitleValid;
		let bodyValid = this.state.isBodyValid;

		switch(fieldName) {
			case 'title':
				titleValid = isNullOrWhitespace(value) ? -1 : 1;
				break;
			case 'body':
				bodyValid = isNullOrWhitespace(value) ? -1 : 1;
				break;
			default:
				break;
		}

		this.setState(
			{
				isTitleValid: titleValid,
				isBodyValid: bodyValid,
			}, this.validateForm);
	}

	validateForm() {
		this.setState(
			{
				valid: this.state.isTitleValid === 1 &&
						this.state.isBodyValid === 1
			});
	}

	render() {
		if (this.state.addingSuc) return <Redirect to="/lobby" />
		return (
			<div className="container">
				<p className="display-4">Создание заявки</p>
				<form onSubmit={this.submitHandler}>
					<div className="row">
						<div className="col-12 col-lg-6 mb-2">
							<p className="jam-order-create-tree-head">Выберите жанры:</p>
						</div>
						<div className="col-12 col-lg-6 mb-2">
							<p className="jam-order-create-tree-head">Выберите интересующие инструменты:</p>
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
					<div className="row">
						<div className="col-6">
							<div className="form-group">
								<label htmlFor="jam-order-create-title">Введите заголовок заявки</label>
								<input
									type="text"
									name="title"
									className="form-control"
									id="jam-order-create-title"
									onChange={this.inputHandler}
									aria-describedby="emailHelp" />
								<small id="emailHelp" className="form-text text-muted">Максимальная длина заголовка 60 символов </small>
							</div>
							<div className="form-group">
								<label htmlFor="jam-order-create-body">Опишите свои требования</label>
								<textarea
									className="form-control"
									name="body"
									onChange={this.inputHandler}
									id="jam-order-create-body"></textarea>
							</div>
							<div className="form-check">
								<input
									className="form-check-input ml-4"
									type="checkbox"
									value=""
									id="jam-order-create-isBand"
									disabled/>
								<label className="form-check-label pl-0" htmlFor="jam-order-create-isBand">
									Группа
								</label>
							</div>
						</div>
					</div>
					<button type="submit" className="btn btn-primary">Создать</button>
				</form>
			</div>
		);
	}

}

export default CreateOrder;