function isNullOrWhitespace(input) {
	return !input || !input.trim();
}

function normalizeNodes(nodes) {
	return nodes.map(node => {
		if (node.children.length == 0)
			return { value: node.value, label: node.label };
		return { value: node.value, label: node.label, children: normalizeNodes(node.children) };
	})
}

export { isNullOrWhitespace, normalizeNodes };