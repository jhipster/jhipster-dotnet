# Contributing to JHipster

Are you ready to contribute to JHipster? We'd love to have you on board, and we will help you as much as we can. Here are the guidelines we'd like you to follow so that we can be of more help:

-   [Questions and help](#question)
-   [Issues and Bugs](#issue)
-   [Feature Requests](#feature)
-   [Submission Guidelines](#submit)
-   [Generator development setup](#setup)
-   [Coding Rules](#rules)
-   [Git Commit Guidelines](#commit)

## <a name="question"></a> Questions and help

This is the JHipster bug tracker, and it is used for [Issues and Bugs](#issue) and for [Feature Requests](#feature). It is **not** a help desk or a support forum.

If you have a question on using JHipster, or if you need help with your JHipster project, please [read our help page](https://www.jhipster.tech/help/) and use the [JHipster tag on StackOverflow](http://stackoverflow.com/tags/jhipster) or join our [Gitter.im chat room](https://gitter.im/jhipster/generator-jhipster).

## <a name="issue"></a> Issues and Bugs

If you find a bug in the source code or a mistake in the documentation, you can help us by [submitting a ticket](https://opensource.guide/how-to-contribute/#opening-an-issue) to our [GitHub issues](https://github.com/nicolas63/jhipster.net-lite/issues). Even better, you can submit a Pull Request to this project.

**Please see the Submission Guidelines below**.

## <a name="feature"></a> Feature Requests

You can request a new feature by submitting a ticket to our [GitHub issues](https://github.com/jhipster/jhipster-vuejs/issues). If you
would like to implement a new feature then consider what kind of change it is:

-   **Major Changes** that you wish to contribute to the project should be discussed first. Please open a ticket which clearly states that it is a feature request in the title and explain clearly what you want to achieve in the description, and the JHipster team will discuss with you what should be done in that ticket. You can then start working on a Pull Request.
-   **Small Changes** can be proposed without any discussion. Open up a ticket which clearly states that it is a feature request in the title. Explain your change in the description, and you can propose a Pull Request straight away.

## <a name="submit"></a> Submission Guidelines

### [Submitting an Issue](https://opensource.guide/how-to-contribute/#opening-an-issue)

If your issue appears to be a bug, and has not been reported, open a new issue.
Help us to maximize the effort we can spend fixing issues and adding new
features, by not reporting duplicate issues. Providing the following information will increase the
chances of your issue being dealt with quickly:

-   **Overview of the issue** - if an error is being thrown a stack trace helps
-   **Motivation for or Use Case** - explain why this is a bug for you
-   **Reproduce the error** - an unambiguous set of steps to reproduce the error.
-   **Related issues** - has a similar issue been reported before?
-   **Suggest a Fix** - if you can't fix the bug yourself, perhaps you can point to what might be
    causing the problem (line of code or commit)

Issues opened without any of these info will be **closed** without any explanation.

### [Submitting a Pull Request](https://opensource.guide/how-to-contribute/#opening-a-pull-request)

Before you submit your pull request consider the following guidelines:

-   Search [GitHub](https://github.com/nicolas63/jhipster.net-lite/pulls) for an open or closed Pull Request
    that relates to your submission.
-   If you want to modify the JHipster generator, read our [Generator development setup](#setup)
-   Make your changes in a new git branch

    ```shell
    git checkout -b my-fix-branch main
    ```

-   Create your patch, **including appropriate test cases**.
-   Follow our [Coding Rules](#rules).
-   Generate a new JHipster project, and ensure that all tests pass

-   Test that the new project runs correctly:

-   You can generate our Continuous Integration (with GitHub Actions)

-   Commit your changes using a descriptive commit message that follows our
    [commit message conventions](#commit-message-format).

    ```shell
    git commit -a
    ```

    Note: the optional commit `-a` command line option will automatically "add" and "rm" edited files.

-   Push your branch to GitHub:

    ```shell
    git push origin my-fix-branch
    ```

-   In GitHub, send a pull request to `jhipster/jhipster-dotnetcore:main`.
-   If we suggest changes then

    -   Make the required updates.
    -   Re-run the JHipster tests on your sample generated project to ensure tests are still passing.
    -   Rebase your branch and force push to your GitHub repository (this will update your Pull Request):

        ```shell
        git rebase main -i
        git push -f
        ```

That's it! Thank you for your contribution!

#### Resolving merge conflicts ("This branch has conflicts that must be resolved")

Sometimes your PR will have merge conflicts with the upstream repository's main branch. There are several ways to solve this but if not done correctly this can end up as a true nightmare. So here is one method that works quite well.

-   First, fetch the latest information from the main

    ```shell
    git fetch upstream
    ```

-   Rebase your branch against the upstream/main

    ```shell
    git rebase upstream/main
    ```

-   Git will stop rebasing at the first merge conflict and indicate which file is in conflict. Edit the file, resolve the conflict then

    ```shell
    git add <the file that was in conflict>
    git rebase --continue
    ```

-   The rebase will continue up to the next conflict. Repeat the previous step until all files are merged and the rebase ends successfully.
-   Re-run the JHipster tests on your sample generated project to ensure tests are still passing.
-   Force push to your GitHub repository (this will update your Pull Request)

    ```shell
    git push -f
    ```

#### After your pull request is merged

After your pull request is merged, you can safely delete your branch and pull the changes
from the main (upstream) repository:

-   Delete the remote branch on GitHub either through the GitHub web UI or your local shell as follows:

    ```shell
    git push origin --delete my-fix-branch
    ```

-   Check out the main branch:

    ```shell
    git checkout main -f
    ```

-   Delete the local branch:

    ```shell
    git branch -D my-fix-branch
    ```

-   Update your main with the latest upstream version:

    ```shell
    git pull --ff upstream main
    ```

## <a name="setup"></a> Generator development setup

Here are the most important steps.

### Fork the jhipster-dotnetcore project

Go to the [jhipster-dotnetcore project](https://github.com/nicolas63/jhipster.net-lite) and click on the "fork" button. You can then clone your own fork of the project, and start working on it.

[Please read the GitHub forking documentation for more information](https://help.github.com/articles/fork-a-repo)

### Use a text editor

We recommend you use a text editor like [VSCode](https://code.visualstudio.com/) to code your changes.


## <a name="rules"></a> Coding Rules

To ensure consistency throughout the source code, keep these rules in mind as you are working:

-   All features or bug fixes **must be tested** by one or more tests.
-   All files must follow the [.editorconfig file](http://editorconfig.org/) located at the root of the JHipster generator project. Please note that generated projects use the same `.editorconfig` file, so that both the generator and the generated projects share the same configuration.

## <a name="commit"></a> Git Commit Guidelines

We have rules over how our git commit messages must be formatted. Please ensure to [squash](https://help.github.com/articles/about-git-rebase/#commands-available-while-rebasing) unnecessary commits so that your commit history is clean.

### <a name="commit-message-format"></a> Commit Message Format

Each commit message consists of a **header**, a **body** and a **footer**.

```
<header>
<BLANK LINE>
<body>
<BLANK LINE>
<footer>
```

Any line of the commit message cannot be longer 100 characters! This allows the message to be easier
to read on GitHub as well as in various git tools.

### Header

The Header contains a succinct description of the change:

-   use the imperative, present tense: "change" not "changed" nor "changes"
-   don't capitalize first letter
-   no dot (.) at the end

### Body

If your change is simple, the Body is optional.

Just as in the Header, use the imperative, present tense: "change" not "changed" nor "changes".
The Body should include the motivation for the change and contrast this with previous behavior.

### Footer

The footer is the place to reference GitHub issues that this commit **Closes**.

You **must** use the [GitHub keywords](https://help.github.com/articles/closing-issues-via-commit-messages) for
automatically closing the issues referenced in your commit.

### Example

For example, here is a good commit message:

```
upgrade to Spring Boot 1.1.7
upgrade the Maven and Gradle builds to use the new Spring Boot 1.1.7,
see http://spring.io/blog/2014/09/26/spring-boot-1-1-7-released
Fix #1234
```
