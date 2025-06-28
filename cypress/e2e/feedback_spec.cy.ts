
describe('Feedback Form', () => {
  it('submits feedback successfully', () => {
    cy.visit('/give-feedback');

    cy.get('#recipient').type('John Doe');
    cy.get('#whatWentWell').type('Great presentation!');
    cy.get('#whatCouldImprove').type('Could have been more interactive.');
    cy.get('#rating').type('4');

    cy.get('button[type="submit"]').click();

    // Add an assertion here to verify the feedback was submitted, e.g., checking for a success message.
  });
});
