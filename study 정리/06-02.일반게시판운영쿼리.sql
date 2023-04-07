-- 게시판 운영 쿼리
-- 단계별로 테스트하고, 데이터가 수정(insert, update, delete)이 되면 commit 한다.

-- 1. 리스트 - 번호, 제목, 작성자, 작성일, 조회수 - 최신글이 맨위로 오도록 한다.
select no, title, writer, writeDate, hit from board
order by no desc;

--  제목에 데이터가 있는 게시글 가져오기.
select no, title, writer, writeDate, hit from board
where title like '%홍길동%' or content like '%홍길동%' or writer like '%홍길동%' 
order by no desc;

-- 2. 보기
--  - 조회 증가
update board set hit = hit + 1 where no = 2;
commit;
--  - 가져온 데이터 - 번호, 제목, 내용, 작성자, 작성일, 조회수
select no, title, writer, writeDate, hit from board
where no = 2;

-- 3. 쓰기 - 제목, 내용, 작성자, 비밀번호 : 글번호 - seq에서 받아온다.
insert into board(no, title, content, writer, pw)
values(board_seq.nextval, '유용한 수정', '정확한 데이터.', '홍길동', '1111');
commit;

-- 4. 수정 - 제목, 내용, 작성자. 글번호와 비밀번호가 맞아야 수정한다.
update board set title='수정수정', content = '수정내용', writer='손흥민'
where no = 2 and pw = '1111';
commit;

-- 5. 삭제
delete from board 
where no =2 and pw ='1111';
commit;