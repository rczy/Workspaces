$(() => {
	attachEventHandlers();
});

const attachEventHandlers = () => {
	$('#list').on('click', async function() {
		$(this).prop('disabled', true);
		const assignments = await fetchAssignments(
			$('#workspace').val(),
			$('#date-from').val(),
			$('#date-to').val()
		);
		const assignments_list = createAssignmentsList(assignments);
		render(assignments_list);
		$(this).prop('disabled', false);
	});
};

const fetchAssignments = async (workspace_id, date_from, date_to) => {
	const url = new URL(`${window.location.origin}/api/assignmentsapi/workspace/${workspace_id}`);
	if (date_from) {
		url.searchParams.append('dateFrom', date_from);
	}
	if (date_to) {
		url.searchParams.append('dateTo', date_to);
	}
	return await $.get(url.toString());
};

const createAssignmentsList = (assignments) => {
	if (!assignments.length) {
		return [];
	}
	const list = new Map();
	for (const a of assignments) {
		const date_key = a.date;
		if (!list.has(date_key)) {
			list.set(date_key, []);
		}
		list.get(date_key).push(`${a.employee.name} [${a.employee.team.name}]`);
	}
	return list;
};

const render = (assignments_list) => {
	const wrapper = $('#result');

	if (!assignments_list.size) {
		wrapper.html('<h3 class="pt-5">Not found...</h3>');
		return;
	}

	let html = '';
	for (const [date, employees] of assignments_list) {
		let items = '';
		for (const e of employees) {
			items += `<li>${e}</li>`;
		}
		html += `<div class="pt-5 text-start"><h4>${date}:</h4><ul>${items}</ul></div>`;
	}
	wrapper.html(html);
};
