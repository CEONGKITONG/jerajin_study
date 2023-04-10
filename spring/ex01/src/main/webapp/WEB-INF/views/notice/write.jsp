<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<h1>공지사항 글쓰기 폼</h1>
<form action="write.do" method="post">
제목 : <input name="title"><br/>
내용 : <textarea rows="5" cols="" name="content"></textarea><br/>
작성자 : <input name="writer"><br/>
공지 시작일 (yyyy-MM-dd): <input name="startDate"><br/>
공지 종료일 (yyyy-MM-dd): <input name="endDate"><br/>
<button>등록</button>
</form>
</body>
</html>