import React from 'react';
import { Redirect, Link } from 'react-router-dom';
import { auth, authorized } from '../../utils/authRequests.js';
import { isNullOrWhitespace } from '../../utils/utils.js';


class LoginWindow extends React.Component {

	constructor(props) {
		super(props);

		this.submitHandler = this.submitHandler.bind(this);
		this.inputHandler = this.inputHandler.bind(this);
		this.validateField = this.validateField.bind(this);
		this.validateForm = this.validateForm.bind(this);

		this.state = {
			isEmailValid: 0,
			isNicknameValid: 0,
			isPasswordValid: 0,
			isPasswordConfirmationValid: 0,

			authValid: true,
			valid: false,

			formErrors: {
				email: "",
				nickname: "",
				password: "",
				passwordConfirmation: ""
			},

			email: "",
			password: "",
		};

	}

	submitHandler (event) {
		if (this.state.valid) {
			auth(
				JSON.stringify({
					Email: this.state.email,
					Password: this.state.password,
				}),
				(ath) => {
					if (!ath) {
						this.setState({
							authValid: false
						});
					}
				}
			);
			this.props.updateAuth();
		}
		event.preventDefault();
	}

	inputHandler (e) {
		const name = e.target.name;
		const value = e.target.value;
		this.setState({[name]: value}, 
			() => { this.validateField(name, value) });
	}

	validateField(fieldName, value) {
		let emailValid = this.state.isEmailValid;
		let passwordValid = this.state.isPasswordValid;

		switch(fieldName) {
			case 'email':
				if (isNullOrWhitespace(value))
					emailValid = 0;
				else
					emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i) ? 1 : -1;
				break;
			case 'password':
				if (isNullOrWhitespace(value))
					passwordValid = 0;
				else
					passwordValid = value.length >= 8 ? 1 : -1;
				break;
			default:
				break;
		}

		this.setState(
			{
				isEmailValid: emailValid,
				isPasswordValid: passwordValid,
			}, this.validateForm);
	}

	validateForm() {
		this.setState(
			{
				valid: this.state.isEmailValid === 1 &&
						this.state.isPasswordValid === 1
			});
	}

	render() {

		let emailDanger = this.state.isEmailValid === 0 ? "" : (this.state.isEmailValid === 1 ? "is-valid" : "is-invalid");
		let passwordDanger = this.state.isPasswordValid === 0 ? "" : (this.state.isPasswordValid === 1 ? "is-valid" : "is-invalid");



		return (
			<form className="card mt-5" onSubmit={this.submitHandler}>
				<div className="card-header text-center">
					<p className="display-3 mb-0 text-info">JustAMusician</p>
				</div>

				<div className="card-body">
					<div className="text-center">
						<p id="jam-auth-title">Авторизация</p>
					</div>
					{ this.state.authValid ? "" : <div className="alert alert-danger" role="alert">Не удалось авторизоваться</div>}
					<div className="form-group">
						<label htmlFor="jam-auth-email">Адрес электронной почты:</label>
						<input id="jam-auth-email"
								name="email"
								type="email"
								className={"form-control " + emailDanger}
								aria-describedby="jam-auth-email-help"
								placeholder="Введите email"
								onChange={this.inputHandler} />
					</div>

					<div className="form-group">
						<label htmlFor="jam-auth-password">Пароль:</label>
						<input id="jam-auth-password"
								name="password"
								type="password"
								className={"form-control " + passwordDanger}
								aria-describedby="jam-auth-password-help"
								placeholder="Придумайте пароль"
								onChange={this.inputHandler} />
						<small id="jam-auth-email-help" className="form-text text-info">
							Длина пароля должна быть не меньше 8 символов
						</small>
					</div>

					<button type="submit" className="btn btn-primary btn-block" disabled={!this.state.valid}>Войти</button>
					<p className="forgot-password text-right"><Link to="/register">Регистрация</Link></p>
				</div>
			</form>
		);
	}

}

export default LoginWindow;