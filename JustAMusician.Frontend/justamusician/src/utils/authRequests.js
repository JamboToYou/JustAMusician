import $ from 'jquery';

const auth = (data, func) => postRequest("http://localhost:5000/api/auth/token")(data,
	(data, status, xhr) => {
		localStorage.setItem("auth", JSON.stringify(data));
		func(true);
	},
	(xhr, errorData, errorThrown) => func(false)
)

const logout = () => {
	if (localStorage.auth)
		localStorage.removeItem("auth");
	if (sessionStorage.auth)
		sessionStorage.removeItem("auth");
}

const register = (data, sucFunc, errFunc) =>
	postRequest("http://localhost:5000/api/auth/signup")(data, sucFunc, errFunc);

const authorized = () => {
	// if (localStorage.getItem("auth")) {
		// let token = JSON.parse(localStorage.getItem("auth")).access_token;
		// rawRequest("http://localhost:5000/api/user/check", "GET", {"Authorization": "Bearer " + token})
		// 		(null, () => func(true), () => func(false));
	// } else {
	if (localStorage.getItem("auth") || sessionStorage.getItem("auth"))
		return true;
	else
		return false;
}

const postRequest = (url) => (data, sucFunc, errFunc) => {
	$.ajax({
		url,
		method: "POST",
		headers: {
			"Access-Control-Allow-Origin": "*",
			"Content-Type": "application/json; charset=utf-8"
		},
		data: data,
		success: (data, status, xhr) => sucFunc(data, status, xhr),
		error: (xhr, errorData, errorThrown) => errFunc(xhr, errorData, errorThrown)
	});
}

const getUser = (sucFunc, errFunc) => {
	let meth = authorizedRequest("http://localhost:5000/api/user/get/", "GET");
	meth ? meth(
		{},
		sucFunc,
		errFunc
		) : null;
};

const getGenres = (sucFunc, errFunc) =>
	authorizedRequest("http://localhost:5000/api/genre/all", "GET")
	(null, sucFunc, errFunc);

const getInstruments = (sucFunc, errFunc) =>
	authorizedRequest("http://localhost:5000/api/instrument/all", "GET")
	(null, sucFunc, errFunc);

const getOrders = (sucFunc, errFunc) =>
	authorizedRequest("http://localhost:5000/api/order/all", "GET")
	(null, sucFunc, errFunc);

const getOrder = (id, sucFunc, errFunc) =>
	authorizedRequest("http://localhost:5000/api/order/" + id, "GET")
	(null, sucFunc, errFunc);

const addOrder = (data, sucFunc, errFunc) =>
	authorizedRequest("http://localhost:5000/api/order", "POST")
	(data, sucFunc, errFunc);

const authorizedRequest = (url, method) => {
	if (localStorage.getItem("auth")) {
		var token = JSON.parse(localStorage.auth).access_token;
		return rawRequest(url, method, {"Authorization": "Bearer " + token});
	} else {
		return null;
	}
};

const rawRequest = (url, method, headers) => (data, sucFunc, errFunc) => {
	$.ajax({
		url,
		method,
		headers: {
			"Access-Control-Allow-Origin": "*",
			"Content-Type": "application/json; charset=utf-8",
			...headers
		},
		data: data,
		success: (data, status, xhr) => sucFunc(data, status, xhr),
		error: (xhr, errorData, errorThrown) => errFunc(xhr, errorData, errorThrown)
	});
}

export {
	auth,
	register,
	authorized,
	logout,
	getUser,
	getGenres,
	getInstruments,
	getOrders,
	getOrder,
	addOrder
};